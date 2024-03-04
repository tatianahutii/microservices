namespace RDMicroservicesSampleApp.Lection2.Cohesion
{
    //Все стосується лише книги
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        //Стосується лише книги
        public void PrintBookDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}");
        }

        //Стосується лише книги
        public void ReadContent()
        {
            Console.WriteLine(Content);
        }
    }

    //Спільний клас для всього
    public class LibraryUtilities
    {
        //Логіка для отримання деталей книги
        public void PrintBookDetails(string title, string author)
        {
            Console.WriteLine($"Title: {title}, Author: {author}");
        }

        //Логіка для відтворення аудіокниги
        public void PlayAudioBook(string file)
        {
            
            Console.WriteLine($"Playing audio book: {file}");
        }

        // Відправлення нагадування електронною поштою
        public void SendReminderEmail(string email, string message)
        {            
            Console.WriteLine($"Sending email to {email} with message: {message}");
        }

        //Логування активності користувача
        public void LogActivity(string activity)
        {            
            Console.WriteLine($"Activity: {activity}");
        }
    }

}
