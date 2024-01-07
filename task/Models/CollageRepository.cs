namespace task.Models

{

    public class CollageRepository

    {

        public static List<Student> Students { get; set; } = new List<Student>()

            {

              new Student

              {

                  Id = 1,

                  StudentName = "Jesus",

                  Email = "studentemail1@gmail.com"

              },

              new Student

              {

                  Id = 2,

                  StudentName = "Mary",

                  Email = "studentemail2@gmail.com",

                  Address = "Tvm , INDIA"

              }

            };

    }

}
