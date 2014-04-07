using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace BARABARES_Services.AppCode
{
    public class BBSessionManager
    {
        private static volatile BBSessionManager _sessionManager;
        private Hashtable _session;
        private Timer _timer;
        private int _sessionTimeOut;

        public int SessionTimeOut
        {
            get { return _sessionTimeOut; }
        }

        private BBSessionManager()
        {
            // Crea hashtable de hashes
            _session = new Hashtable();

            //_sessionTimeOut = Int32.Parse(ConfigurationManager.AppSettings[Constants.SESSION_TIME_OUT].ToString());
            _sessionTimeOut = Int32.Parse("10");

            // Empieza el timer de la sesion

            //float timerInterval = float.Parse(ConfigurationManager.AppSettings[Constants.TIMER_INTERVAL].ToString());
            float timerInterval = float.Parse("5");

            int intInMilliseconds = Convert.ToInt32(timerInterval * 60000);
            _timer = new Timer(intInMilliseconds);
            _timer.AutoReset = true;
            //_timer.Elapsed += new ElapsedEventHandler(handleOpenSessions);
            _timer.Start();
        }

        // Singleton pattern
        public static BBSessionManager Instance
        {
            get
            {
                if (_sessionManager == null)
                {
                    _sessionManager = new BBSessionManager();
                }
                return _sessionManager;
            }
        }

        public Hashtable groupList
        {
            get
            {
                if (!_session.Contains(Constants.GROUP_LIST))
                    _session.Add(Constants.GROUP_LIST, new Hashtable());
                return ((Hashtable)_session[Constants.GROUP_LIST]);
            }
        }

        public Hashtable userList
        {
            get
            {
                if (!_session.Contains(Constants.USER_LIST))
                    _session.Add(Constants.USER_LIST, new Hashtable());
                return ((Hashtable)_session[Constants.USER_LIST]);
            }
        }

        public Hashtable tokenList
        {
            get
            {
                if (!_session.Contains(Constants.TOKEN_LIST))
                    _session.Add(Constants.TOKEN_LIST, new Hashtable());
                return ((Hashtable)_session[Constants.TOKEN_LIST]);
            }
        }


        #region PUBLIC METHODS

        // Valida el token y saca los expirados
        public Boolean isValidToken(string token)
        {
            handleTokenExpires(token);
            return _isValidToken(token);
        }

        // Logout saca el token del tokenList
        public void logOut(string token)
        {
            if (_isValidToken(token))
            {
                tokenList.Remove(token);
            }
        }

        // *** FALTA
        // Agrega una nueva sesion al tokenList hashtable
        public string addNewSession(int userId, string userName, string withToken, int groupId)
        {
            if (!_userIsAlreadyLogged(userName))
            {
                SessionUser user = new SessionUser();
                user.IdUsuario = userId;
                user.Nombre = userName;
                user.UltimoLogin = DateTime.UtcNow;
                user.IdPerfil = groupId;
                tokenList.Add(withToken, user);

                //Agregar al groupList

                return withToken;
            }
            else
            {
                return _GetTokenFromLoggedUser(userName);
            }
        }

        public int getUserGroupIdByToken(string token)
        {
            if (_isValidToken(token))
            {
                return ((SessionUser)tokenList[token]).IdPerfil;
            }
            return 0;
        }

        public int getUserIdByToken(string token)
        {
            if (_isValidToken(token))
            {
                return ((SessionUser)tokenList[token]).IdUsuario;
            }
            return 0;
        }

        public void shutDownAllSessions()
        {
            // Prevenir la excepcion cuando token list es null
            if (tokenList == null) return;

            ArrayList expiredTokens = new ArrayList();

            foreach (DictionaryEntry entry in tokenList)
            {
                expiredTokens.Add(entry.Key);
            }

            for (int i = 0; i < expiredTokens.Count; i++)
            {
                tokenList.Remove(expiredTokens[i].ToString());
            }
        }

        #endregion

        #region PRIVATE METHODS

        // Verifica si el usuario ya existe en el tokenList
        private bool _userIsAlreadyLogged(string userName)
        {
            foreach (DictionaryEntry entry in tokenList)
            {
                SessionUser user = (SessionUser)entry.Value;
                if (userName == user.Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        private string _GetTokenFromLoggedUser(string userName)
        {
            foreach (DictionaryEntry entry in tokenList)
            {
                SessionUser user = (SessionUser)entry.Value;
                if (userName == user.Nombre)
                {
                    return entry.Key.ToString();
                }
            }
            return string.Empty;
        }

        // Verificar que el token este en el tokenList
        private Boolean _isValidToken(string token)
        {
            if (tokenList == null) return false;
            return tokenList.ContainsKey(token);
        }

        // Matar los tokens que estan expirados
        private void handleOpenSessions(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.UtcNow;

            // remover los tokens del Hashtable
            ArrayList expiredTokens = new ArrayList();
            if (tokenList == null) return;
            foreach (DictionaryEntry entry in tokenList)
            {
                // saco el usuario del entro del tokenList
                SessionUser user = (SessionUser)entry.Value;

                DateTime expiresTime = new DateTime(); // = saco la fecha del lastLogin luego aumento el timeout
                // lastLogin.AddMinutes(_sessionTimeOut);

                if (now.Ticks > expiresTime.Ticks)
                {
                    expiredTokens.Add(entry.Key);
                }
            }

            // Saco del Hashtable los tokens que ya expiraron
            for (int i = 0; i < expiredTokens.Count; i++)
            {
                tokenList.Remove(expiredTokens[i].ToString());
            }
        }

        // Reviso la sesion. Si esta expirada la saco, sino le doy mas tiempo de vida
        private void handleTokenExpires(string token)
        {
            DateTime now = DateTime.UtcNow;

            if (_isValidToken(token))
            {
                SessionUser user = (SessionUser)tokenList[token];
                DateTime expiresTime = user.UltimaActividad.AddMinutes(_sessionTimeOut);
                if (now.Ticks > expiresTime.Ticks)
                {
                    tokenList.Remove(token);
                }
                else
                {
                    //user.lastActivity = now;
                    tokenList[token] = user;
                }
            }

        }

        #endregion
    }
}