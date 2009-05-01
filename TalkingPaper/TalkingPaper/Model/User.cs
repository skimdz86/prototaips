using System;
using System.Collections.Generic;
using System.Text;

namespace TalkingPaper
{
    class User
    {
        private String username;
        private String password;
        private String classe;//optional
        private bool flagAdmin;

        public User(String username, String password, bool flagAdmin) {
            this.username = username;
            this.password = password;
            this.flagAdmin = flagAdmin;
        }

        public String getUsername() { return username; }
        public void setUsername(String username) { this.username = username; }
        public String getPassword() { return password; }
        public void setPassword(String password) { this.password = password; }
        public bool getFlagAdmin() { return flagAdmin; }
        public void setFlagAdmin(bool flagAdmin) { this.flagAdmin = flagAdmin; }

    }
}
