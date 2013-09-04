using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class VotingFull
    {
        public VotingFull(string resourceUri)
        {
            m_resourceUri = resourceUri;
        }

        #region Properties

        private string m_resourceUri;

        public string ResourceUri
        {
            get { return m_resourceUri; }
            set { m_resourceUri = value; }
        }


        private int m_abstains;

        public int Abstains
        {
            get { return m_abstains; }
            set { m_abstains = value; }
        }

        private int m_againstVotes;

        public int AgainstVotes
        {
            get { return m_againstVotes; }
            set { m_againstVotes = value; }
        }

        private bool m_assent;

        public bool Assent
        {
            get { return m_assent; }
            set { m_assent = value; }
        }

        private int m_attendee;

        public int Attendee
        {
            get { return m_attendee; }
            set { m_attendee = value; }
        }

        private int m_forVotes;

        public int ForVotes
        {
            get { return m_forVotes; }
            set { m_forVotes = value; }
        }

        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private int m_noVotes;

        public int NoVotes
        {
            get { return m_noVotes; }
            set { m_noVotes = value; }
        }

        private int m_number;

        public int Number
        {
            get { return m_number; }
            set { m_number = value; }
        }

        private string m_recordText;

        public string RecordText
        {
            get { return m_recordText; }
            set { m_recordText = value; }
        }

        private int m_sessionId;

        public int SessionId
        {
            get { return m_sessionId; }
            set { m_sessionId = value; }
        }

        private string m_subGroupText;

        public string SubGroupText
        {
            get { return m_subGroupText; }
            set { m_subGroupText = value; }
        }

        private string m_subGroupTitle;

        public string SubGroupTitle
        {
            get { return m_subGroupTitle; }
            set { m_subGroupTitle = value; }
        }

        private string m_title;

        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        private List<Vote> m_votes;

        public List<Vote> Votes
        {
            get { return m_votes; }
            set { m_votes = value; }
        }

        #endregion

        #region Method

        public bool isEmpty()
        {
            //Yeah I check only Title, because all the session have a Title
            if (string.IsNullOrEmpty(Title) == true)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
