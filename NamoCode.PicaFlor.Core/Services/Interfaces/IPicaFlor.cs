using NamoCode.PicaFlor.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Services.Interfaces
{
    public interface IPicaFlorService
    {
        void GetGroups(int limit , int offset , Action<List<ParlamentaryGroup>> callbackOK, Action<Exception> callbackError);
        void GetGroup(string id, Action<ParlamentaryGroup> callbackOK, Action<Exception> callbackError);

        void GetGroupMembers(int limit , int offset , Action<List<ParlamentaryMember>> callbackOK, Action<Exception> callbackError);
        void GetGroupMember(string id , Action<ParlamentaryMember> callbackOK, Action<Exception> callbackError);

        void GetMembers(int limit , int offset , Action<List<ParlamentaryMember>> callbackOK, Action<Exception> callbackError);
        void GetMember(string id , Action<ParlamentaryMember> callbackOK, Action<Exception> callbackError);

        void GetParties(int limit , int offset , Action<List<Party>> callbackOK , Action<Exception> callbackError);
        void GetParty(string id , Action<Party> callbackOk , Action<Exception> callbackError);

        void GetSessions(int limit, int offset, bool orderBy, Action<List<Session>> callbackOK, Action<Exception> callbackError);
        void GetSession(string id, Action<Session> callbackOK, Action<Exception> callbackError);

        void GetVoteFull(int limit, int offset, Action<List<VotingFull>> callbackOK, Action<Exception> callbackError);
        void GetVoteFull(string id, Action<VotingFull> callbackOK, Action<Exception> callbackError);
        void GetVoteFullByUri(string uri, Action<VotingFull> callbackOK, Action<Exception> callbackError);
    }
}
