namespace JWT_20
{
    public interface IBildirim
    {
        string Gonder();

    }
    public class Eposta : IBildirim
    {
        public string Gonder()
        {
            return "Eposta gönderildi";

        }

    }
    public class SMS : IBildirim
    {
        public string Gonder()
        {
            return "SMS gönderildi";

        }

    }

}
