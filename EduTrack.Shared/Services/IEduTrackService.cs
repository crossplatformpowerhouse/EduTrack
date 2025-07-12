using EduTrack.Shared.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Shared.Services
{
	public interface IEduTrackService
	{
		Task<IEnumerable<User>> GetUsersAsync();
		Task<IEnumerable<CourseType>> GetCourseTypesAsync();
		Task<IEnumerable<Course>> GetCoursesAsync();
		Task<IEnumerable<Subject>> GetSubjectsAsync();
		Task<IEnumerable<AssignmentType>> GetAssignmentTypesAsync();
		Task<IEnumerable<ExamType>> GetExamTypesAsync();
		Task<IEnumerable<Assignment>> GetAssignmentsAsync();
		Task<IEnumerable<Grade>> GetGradesAsync();
		Task<IEnumerable<Account>> GetAccountsAsync();
		Task<IEnumerable<About>> GetAboutsAsync();
		Task<IEnumerable<StudentDetailsDto>> GetStudentDetailsAsync(int userId);
	}
}
