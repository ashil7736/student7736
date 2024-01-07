using Microsoft.AspNetCore.Mvc;

using task.Models;



namespace task.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class StudentController : ControllerBase

    {

        private object iteam;



        public object? Students { get; private set; }



        [HttpGet]

        [Route("All", Name = "GetAllStudents")]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [ProducesResponseType(StatusCodes.Status200OK)]

        public IEnumerable<Student> GetStudents()

        {

            return CollageRepository.Students;



        }

        [HttpGet]

        [Route("{id:int}", Name = "GetStudentById")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> GetStudentById(int id)

        {

            // BadRequest-400-Badrequest-Client error

            if (id <= 0)

                return BadRequest();

            var student = CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            // Not Found -404-notFound-Client error

            if (student == null)

                return NotFound($" The student with id {id} not found");

            var studentDTO = new StudentDTO()

            {

                Id = student.Id,

                StudentName = student.StudentName,

                Address = student.Address,

                Email = student.Email

            };





            // ok- 200- success

            return Ok(studentDTO);

        }

        [HttpGet]

        [Route("{name:alpha}", Name = "GetStudentByName")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> GetStudentByName(string name)

        {

            // BadRequest-400-Badrequest-Client error

            if (string.IsNullOrEmpty(name))

                return BadRequest();

            var student = CollageRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();

            // Not Found -404-notFound-Client error

            if (student == null)

                return NotFound($" The student with id {name} not found");

            var studentDTO = new StudentDTO()

            {

                Id = student.Id,

                StudentName = student.StudentName,

                Address = student.Address,

                Email = student.Email

            };



            // ok-200-success

            return Ok(studentDTO);

        }

        [HttpPost]

        [Route("Create")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]



        //api/student/create

        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)

        {

            if (model == null)

                return BadRequest();

            int newId = CollageRepository.Students.LastOrDefault().Id + 1;

            Student student = new Student

            {

                Id = newId,

                StudentName = model.StudentName,

                Address = model.Address,

                Email = model.Email

            };

            CollageRepository.Students.Add(student);

            model.Id = student.Id;

            return Ok(student);

        }

        [HttpPut]

        [Route("Update")]

        //api/student/update

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status204NoContent)]





        public ActionResult UpdateStudent([FromBody] StudentDTO model)

        {

            if (model == null || model.Id <= 0)

                BadRequest();

            var existingStudent = CollageRepository.Students.Where(S => S.Id == model.Id).FirstOrDefault();

            if (existingStudent == null)

                return NotFound();

            existingStudent.StudentName = model.StudentName;

            existingStudent.Address = model.Address;

            existingStudent.Email = model.Email;

            return NoContent();

        }

        [HttpDelete("{id}", Name = "DeleteStudentById")]

        [ProducesResponseType(StatusCodes.Status200OK)]

        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<bool> DeleteStudent(int id)

        {

            // BadRequest-400-Badrequest-Client error

            if (id <= 0)

                return BadRequest();

            var student = CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            // Not Found -404-notFound-Client error

            if (student == null)

                return NotFound($" The student with id {id} not found");





            CollageRepository.Students.Remove(student);

            // ok- 200- success

            return Ok(true);

        }





    }

}
