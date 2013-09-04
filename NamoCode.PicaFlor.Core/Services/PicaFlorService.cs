using NamoCode.Mvx.Core.Utils.Net;
using NamoCode.PicaFlor.Core.Model;
using NamoCode.PicaFlor.Core.Services.Interfaces;
using NamoCode.PicaFlor.Core.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;

namespace NamoCode.PicaFlor.Core.Services
{
    public class PicaFlorService : IPicaFlorService
    {
        public void GetGroups(int limit, int offset, Action<List<ParlamentaryGroup>> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetGroup(limit, offset),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseParlamentaryGroups(jobject));
                },
                callbackError);

        }

        public void GetGroup(string id, Action<Model.ParlamentaryGroup> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetGroup(id),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseParlamentaryGroup(jobject));
                },                    
                callbackError);
        }

        public void GetGroupMembers(int limit, int offset, Action<List<ParlamentaryMember>> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetGroupMember(limit, offset),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseGroupMembers(jobject));
                },                    
                callbackError);
        }

        public void GetGroupMember(string id, Action<Model.ParlamentaryMember> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetGroupMember(id),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseGroupMember(jobject));
                },                    
                callbackError);
        }

        public void GetMembers(int limit, int offset, Action<List<ParlamentaryMember>> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetMember(limit, offset),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseMembers(jobject));
                },
                callbackError);
        }

        public void GetMember(string id, Action<ParlamentaryMember> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetMember(id),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseMember(jobject));
                },                    
                callbackError);
        }

        public void GetParties(int limit, int offset, Action<List<Model.Party>> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetParty(limit, offset),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseParties(jobject));
                },                    
                callbackError);
                
        }

        public void GetParty(string id, Action<Party> callbackOk, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetParty(id),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOk.Invoke(new PicaFlorJsonHelper().ParseParty(jobject));
                },                    
                callbackError);
        }

        public void GetSessions(int limit, int offset, bool orderBy, Action<List<Model.Session>> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetSession(limit, offset),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseSessions(jobject));
                },                    
                callbackError);
                
        }

        public void GetSession(string id, Action<Model.Session> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetSession(id),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseSession(jobject));
                },                    
                callbackError);
        }

        public void GetVoteFull(int limit, int offset, Action<List<VotingFull>> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetVoteFull(limit, offset),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseVoteFulls(jobject));
                },                    
                callbackError);
        }

        public void GetVoteFull(string id, Action<VotingFull> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetVoteFull(id),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseVoteFull(jobject));
                },                    
                callbackError);
        }

        public void GetVoteFullByUri(string uri, Action<VotingFull> callbackOK, Action<Exception> callbackError)
        {
            new HttpCalls().Get(
                new PicaFlorRouting().GetVoteFullUri(uri),
                (stream) =>
                {
                    var jobject = JObject.Parse(new StreamReader(stream).ReadToEnd());

                    callbackOK.Invoke(new PicaFlorJsonHelper().ParseVoteFull(jobject));
                },                    
                callbackError);
        }
        
    }
}
