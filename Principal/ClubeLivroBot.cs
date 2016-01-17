using TelegramBot;
using TelegramBot.Model;

namespace ClubeLivroTelegramBot
{
    internal class ClubeLivroBot : ITelegramBotListener
    {
        private static ClubeLivroBot _i;

        private long _intOffSet = 0;

        public static ClubeLivroBot i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new ClubeLivroBot();

                return _i;
            }
        }

        public long intOffSet
        {
            get
            {
                return _intOffSet;
            }

            set
            {
                _intOffSet = value;
            }
        }

        public int intTimeOut
        {
            get
            {
                return (60 * 5);
            }
        }

        public string strBotToken
        {
            get
            {
                return "171171886:AAHhb5ov5BA-CPlVi6IJ96rd-NBJn9d-pSQ";
            }
        }

        public string strCertificatePfxPass
        {
            get
            {
                return "183729";
            }
        }

        public string strCertificatePfxPath
        {
            get
            {
                return "certificate.pem";
            }
        }

        public string url
        {
            get
            {
                return "https://177.91.192.94:88";
            }
        }

        private ClubeLivroBot()
        {
        }

        public void onUpdate(Update[] arrObjUpdate)
        {
            if (arrObjUpdate == null)
            {
                return;
            }

            foreach (Update objUpdate in arrObjUpdate)
            {
                this.processUpdate(objUpdate);
            }
        }

        private static void Main(string[] args)
        {
            ServerBot.i.objITelegramBotListener = ClubeLivroBot.i;
            ServerBot.i.start();
        }

        private void processUpdate(Update objUpdate)
        {
            if (objUpdate == null)
            {
                return;
            }

            this.intOffSet = (objUpdate.intId + 1);

            if (objUpdate.objMessage != null)
            {
                this.processUpdateMessage(objUpdate);
                return;
            }
        }

        private void processUpdateMessage(Update objUpdate)
        {
            this.sendInConstruction(objUpdate);
        }

        private void sendInConstruction(Update objUpdate)
        {
            TelegramServer.i.sendMessage(objUpdate.objMessage.objChat.intId, "Ainda estou sendo construído...");
        }
    }
}