using NamoCode.PicaFlor.Core.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NamoCode.Mvx.Core.ExtensionMethods;

namespace NamoCode.PicaFlor.Core.Utils
{
    public class PicaFlorJsonHelper
    {


        private const string c_objects = "objects";

        public List<ParlamentaryGroup> ParseParlamentaryGroups(JObject jobject)
        {
            var parlamentaryGroups = jobject.SelectToken(c_objects);
            List<ParlamentaryGroup> groups = new List<ParlamentaryGroup>();

            foreach (JObject objeto in parlamentaryGroups)
            {
                groups.Add(ParseParlamentaryGroup(objeto));
            }

            return groups;
        }


        private const string c_acronym = "acronym";
        private const string c_congressUrl = "congress_url";
        private const string c_id = "id";

        private const string c_members = "objects";

        public ParlamentaryGroup ParseParlamentaryGroup(JObject jobject)
        {
            return new ParlamentaryGroup()
            {
                Acronym = jobject.SelectToken(c_acronym).ValueOrDefault<string>(),
                CongressUrl = jobject.SelectToken(c_congressUrl).ValueOrDefault<string>(),
                Id = jobject.SelectToken(c_id).ValueOrDefault<int>()  ,
                ParlamentaryMembers = ParseParlamentaryMembers((JArray)jobject.SelectToken(c_members))          
            };
        }

        public List<ParlamentaryMember> ParseGroupMembers(JObject jobject)
        {
            return ParseParlamentaryMembers((JArray)jobject.SelectToken(c_members));
        }

        public List<ParlamentaryMember> ParseMembers(JObject jobject)
        {
            return ParseParlamentaryMembers((JArray)jobject.SelectToken(c_members));
        }
        
        protected List<ParlamentaryMember> ParseParlamentaryMembers(JArray jobject)
        {
            List<ParlamentaryMember> members = new List<ParlamentaryMember>();

            foreach (JToken member in jobject)
            {
                members.Add(ParseParlamentaryMember((JObject)member));
            }

            return members;
        }

        private const string c_member = "member";        
        private const string c_avatar = "avatar";
        private const string c_congressId = "congress_id";
        private const string c_congressWeb = "congress_web";
        private const string c_division = "division";
        private const string c_email = "email";        
        private const string c_name = "name";
        private const string c_resource_uri = "resource_uri";
        private const string c_secondName = "second_name";
        private const string c_twitter = "twitter";
        private const string c_web = "web";

        public ParlamentaryMember ParseGroupMember(JObject jobject)
        {
            return ParseParlamentaryMember((JObject)jobject.SelectToken(c_member));
        }

        public ParlamentaryMember ParseMember(JObject jobject)
        {
            return ParseParlamentaryMember(jobject);
        }

        protected ParlamentaryMember ParseParlamentaryMember(JObject jobject)
        {
            return new ParlamentaryMember()
            {
                Avatar = jobject.SelectToken(c_avatar).ValueOrDefault<string>(),
                CongressId = jobject.SelectToken(c_congressId).ValueOrDefault<int>(),
                CongressWeb = jobject.SelectToken(c_congressWeb).ValueOrDefault<string>(),
                Division = jobject.SelectToken(c_division).ValueOrDefault<string>(),
                Email = jobject.SelectToken(c_email).ValueOrDefault<string>(),
                Id = jobject.SelectToken(c_id).ValueOrDefault<int>(),
                Name = jobject.SelectToken(c_name).ValueOrDefault<string>(),
                LastName = jobject.SelectToken(c_secondName).ValueOrDefault<string>(),
                Twitter = jobject.SelectToken(c_twitter).ValueOrDefault<string>(),
                Web = jobject.SelectToken(c_web).ValueOrDefault<string>()
            };
        }

        public List<Party> ParseParties(JObject jobject)
        {
            List<Party> parties = new List<Party>();

            foreach (var element in jobject.SelectToken(c_objects))
            {
                parties.Add(ParseParty(element));
            }

            return parties;
        }

        private const string c_logo = "logo";
        
        public Party ParseParty(JToken jobject)
        {
            return new Party()
            {
                Id = jobject.SelectToken(c_id).ValueOrDefault<int>(),
                Logo = jobject.SelectToken(c_logo).ValueOrDefault<string>(),
                Name = jobject.SelectToken(c_name).ValueOrDefault<string>(),
                Web = jobject.SelectToken(c_web).ValueOrDefault<string>()
            };
        }

        public List<Session> ParseSessions(JObject jobject)
        {
            List<Session> sessions = new List<Session>();

            foreach (var element in jobject.SelectToken(c_objects))
            {
                sessions.Add(ParseSession(element));
            }

            return sessions;
        }

        private const string c_session = "session";
        private const string c_votings = "votings";
        private const string c_date = "date";

        public Session ParseSession(JToken jobject)
        {
            return new Session()
            {
                Date = jobject.SelectToken(c_date).ValueOrDefault<DateTime>(),
                Id = jobject.SelectToken(c_id).ValueOrDefault<int>(),
                SessionNumber = jobject.SelectToken(c_session).ValueOrDefault<int>(),
                Votes = ParseVotingUris((JArray)jobject.SelectToken(c_votings))
            };
        }

        public List<VotingFull> ParseVotingUris(JArray jarray)
        {
            List<VotingFull> votingFull = new List<VotingFull>();

            foreach (var element in jarray)
            {
                votingFull.Add(new VotingFull(element.ValueOrDefault<string>()));
            }

            return votingFull;
        }

        public List<VotingFull> ParseVoteFulls(JObject jobject)
        {
            List<VotingFull> votingFull = new List<VotingFull>();

            foreach (var element in jobject.SelectToken(c_objects))
            {
                votingFull.Add(ParseVoteFull(element));
            }

            return votingFull;
        }

        private const string c_abstains = "abstains";
        private const string c_againstVotes = "against_votes";
        private const string c_assent = "assent";
        private const string c_attende = "attende";
        private const string c_forVotes = "for_votes";
        private const string c_noVotes = "no_votes";
        private const string c_number = "number";
        private const string c_recordtext = "record_text";
        private const string c_subgroupText = "subgroup_text";
        private const string c_subgroupTitle = "subgroup_title";
        private const string c_title = "title";
        private const string c_votes = "votes";
        private const string c_resourceUri = "resource_uri";


        public VotingFull ParseVoteFull(JToken jobject)
        {
            return new VotingFull(jobject.SelectToken(c_resourceUri).ValueOrDefault<string>())
            {
                Abstains = jobject.SelectToken(c_abstains).ValueOrDefault<int>(),
                AgainstVotes = jobject.SelectToken(c_againstVotes).ValueOrDefault<int>(),
                Assent = jobject.SelectToken(c_assent).ValueOrDefault<bool>(),
                Attendee = jobject.SelectToken(c_attende).ValueOrDefault<int>(),
                ForVotes = jobject.SelectToken(c_forVotes).ValueOrDefault<int>(),
                NoVotes = jobject.SelectToken(c_noVotes).ValueOrDefault<int>(),
                Number = jobject.SelectToken(c_number).ValueOrDefault<int>(),
                RecordText = jobject.SelectToken(c_recordtext).ValueOrDefault<string>(),
                SubGroupText = jobject.SelectToken(c_subgroupText).ValueOrDefault<string>(),
                SubGroupTitle = jobject.SelectToken(c_subgroupTitle).ValueOrDefault<string>(),
                Title = jobject.SelectToken(c_title).ValueOrDefault<string>(),   
                Votes = ParseVotes((JArray)jobject.SelectToken(c_votes))
            };
        }

        

        public List<Vote> ParseVotes(JArray jarray)        
        {
            List<Vote> votes = new List<Vote>();

            foreach (JToken token in jarray)
            {
                votes.Add(this.ParseVote(token));
            }

            return votes;
        }

        private const string c_deleteUri = "/api/v1/member/";
        private const string c_vote = "vote";

        public Vote ParseVote(JToken token)
        {
            return new Vote()
            {
                Id = token.SelectToken(c_id).ValueOrDefault<int>(),
                MemberId = int.Parse(token.SelectToken(c_member).ValueOrDefault<string>().Replace(c_deleteUri , "").Replace("/" , "")),
                VoteValue = token.SelectToken(c_vote).ValueOrDefault<string>()
            };
        }
    }
}
