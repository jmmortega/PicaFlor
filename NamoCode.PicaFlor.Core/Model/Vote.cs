using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class Vote
    {
        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private int m_memberId;

        public int MemberId
        {
            get { return m_memberId; }
            set { m_memberId = value; }
        }
        
        private string m_voteValue;

        public string VoteValue
        {
            get { return m_voteValue; }
            set { m_voteValue = value; }
        }


    }
}
