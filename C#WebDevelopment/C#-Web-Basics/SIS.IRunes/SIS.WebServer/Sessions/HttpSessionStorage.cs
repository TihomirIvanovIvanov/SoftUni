namespace SIS.MvcFramework.Sessions
{
    using HTTP.Sessions;
    using System.Collections.Concurrent;

    public class HttpSessionStorage : IHttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private readonly ConcurrentDictionary<string, IHttpSession> httpSessions;

        public HttpSessionStorage()
        {
            this.httpSessions = new ConcurrentDictionary<string, IHttpSession>();
        }

        public IHttpSession GetSession(string id)
        {
            return this.httpSessions.GetOrAdd(id, _ => new HttpSession(id));
        }

        public bool ContainsSession(string sessionId)
        {
            return this.httpSessions.ContainsKey(sessionId);
        }
    }
}
