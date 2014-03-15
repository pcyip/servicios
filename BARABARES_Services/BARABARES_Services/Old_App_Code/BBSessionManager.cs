using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Timers;
using System.Web;

namespace BARABARES_Services.App_Code
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
            //empieza el timer de la sesion
            _session = new Hashtable();
            //_sessionTimeOut = Int32.Parse(ConfigurationManager.AppSettings[Constants.SESSION_TIME_OUT].ToString());
            //float timerInterval = float.Parse(ConfigurationManager.AppSettings[Constants.TIMER_INTERVAL].ToString());
            //int intInMilliseconds = Convert.ToInt32(timerInterval * 60000);
            //_timer = new Timer(intInMilliseconds);
            _timer.AutoReset = true;
            _timer.Elapsed += new ElapsedEventHandler(handleOpenSessions);
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

        public Boolean isValidToken(string token)
        {
            handleTokenExpires(token);
            return _isValidToken(token);
        }

        public void logOut(string token)
        {
            if (_isValidToken(token))
            {
                tokenList.Remove(token);
            }
        }

        #endregion

        #region PRIVATE METHODS

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
                // User user = (User)entry.Value;

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

        }

        #endregion

    }
}