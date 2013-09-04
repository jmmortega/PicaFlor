using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Utils
{
    public class PicaFlorRouting
    {
        private const string c_mainUrl = "http://proyectocolibri.es/{0}/{1}";
        private const string c_mainUrlByUri = "http://proyectocolibri.es/{0}";
        private const string c_parameters = "?api_key=special-key&limit={0}&offset={1}";
        private const string c_parameter = "?api_key=special-key";


        #region Methods

        private const string c_getGroup = "api/v1/group";
        public string GetGroup(int limit = 20, int offset = 0)
        {
            return FormatRequest(limit , offset, c_getGroup);
        }

        private const string c_getGroupId = "api/v1/group/{0}";
        public string GetGroup(string id)
        {
            return FormatRequest(id , c_getGroupId);
        }

        private const string c_groupMember = "api/v1/groupmember";
        public string GetGroupMember(int limit = 20, int offset = 0)
        {
            return FormatRequest(limit, offset , c_groupMember);
        }

        private const string c_groupMemberId = "api/v1/groupmember/{0}";
        public string GetGroupMember(string id)
        {
            return FormatRequest(id , c_groupMemberId);
        }

        private const string c_Member = "api/v1/member";
        public string GetMember(int limit = 20, int offset = 0)
        {
            return FormatRequest(limit, offset, c_Member);
        }

        private const string c_MemberId = "api/v1/member/{0}";
        public string GetMember(string id)
        {
            return FormatRequest(id, c_MemberId);
        }

        private const string c_Party = "api/v1/party";
        public string GetParty(int limit = 20, int offset = 0)
        {
            return FormatRequest(limit, offset, c_Party);
        }

        private const string c_PartyId = "api/v1/party/{0}";
        public string GetParty(string id)
        {
            return FormatRequest(id, c_PartyId);
        }

        private const string c_Session = "api/v1/session";
        private const string c_date = "&order_by={0}date";
        public string GetSession(int limit = 20, int offset = 0 , bool orderby = true)
        {
            string uri = FormatRequest(limit, offset, c_Session);

            if (orderby == true)
            {
                uri += string.Format(c_date, new object[] { "-" });
            }
            else
            {
                uri += string.Format(c_date, new object[] { "" });
            }

            return uri;
        }

        private const string c_SessionId = "api/v1/session/{0}";
        public string GetSession(string id)
        {
            return FormatRequest(id, c_SessionId);
        }

        private const string c_VoteFull = "api/v1/vote_full";
        public string GetVoteFull(int limit = 20, int offset = 0)
        {
            return FormatRequest(limit, offset, c_VoteFull);
        }

        private const string c_VoteFullId = "api/v1/vote_full/{0}";
        public string GetVoteFull(string id)
        {
            return FormatRequest(id, c_VoteFullId);
        }

        public string GetVoteFullUri(string uri)
        {
            return FormatRequest(uri);
        }

        #endregion

#region Private Methods


        private string FormatRequest(int limit , int offset , string url)
        {
             return string.Format(string.Format(c_mainUrl, new object[]{
                url , 
                string.Format(c_parameters, new object[] {limit.ToString() , offset.ToString()})}));
        }

        private string FormatRequest(string id , string url)
        {
            return string.Format(string.Format(c_mainUrl, new object[]{
                string.Format(url , new object[] {id}),
                c_parameter}));
        }

        private string FormatRequest(string uri)
        {
            return string.Format(c_mainUrlByUri, new object[] { uri });            
        }

#endregion



    }
}
