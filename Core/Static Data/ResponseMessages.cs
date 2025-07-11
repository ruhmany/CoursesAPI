using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RahmanyCourses.Core.Static_Data
{
    public class ResponseMessages
    {
        #region UserCrudOperationsMessages
        public static string CreateUserSuccesseded = "User Created Successfuly";
        public static string CreateUserFail = "Creating User Failed";
        public static string UserNotFound = "User Not Found";
        public static string UserAlreadyExists = "User Already Exists";
        public static string UserUpdated = "User Updated Successfuly";
        public static string UserDeleted = "User Deleted Successfuly";
        public static string UserNotDeleted = "User Not Deleted";
        #endregion

        #region RoleCrudOperationsMessages
        public static string UserRoleNotFound = "User Role Not Found";
        public static string UserRoleAlreadyExists = "User Role Already Exists";
        public static string UserRoleCreated = "User Role Created Successfuly";
        public static string UserRoleUpdated = "User Role Updated Successfuly";
        public static string UserRoleDeleted = "User Role Deleted Successfuly";
        public static string UserRoleNotDeleted = "User Role Not Deleted";
        #endregion

        #region CourseCrudOperationsMessages
        public static string CourseCreated = "Course Created Successfuly";
        public static string CourseUpdated = "Course Updated Successfuly";
        public static string CourseDeleted = "Course Deleted Successfuly";
        public static string CourseNotFound = "Course Not Found";
        public static string CourseAlreadyExists = "Course Already Exists";
        public static string CourseNotDeleted = "Course Not Deleted";
        public static string CourseNotUpdated = "Course Not Updated";
        public static string CourseAlreadyPublished = "Course Already Published";
        public static string CoursePublished = "Course Published Successfuly";
        public static string CourseNotPublished = "Course Not Published";
        public static string CourseAlreadyUnpublished = "Course Already Unpublished";
        public static string CourseUnpublished = "Course Unpublished Successfuly";
        public static string CourseNotUnpublished = "Course Not Unpublished";
        public static string CourseAlreadyArchived = "Course Already Archived";
        public static string CourseArchived = "Course Archived Successfuly";
        public static string CourseNotArchived = "Course Not Archived";
        public static string CourseAlreadyUnarchived = "Course Already Unarchived";
        public static string CourseUnarchived = "Course Unarchived Successfuly";
        public static string CourseNotUnarchived = "Course Not Unarchived";
        public static string CourseAlreadyDeleted = "Course Already Deleted";
        #endregion

        #region LessonCrudOperationsMessages
        public static string LessonCreated = "Lesson Created Successfuly";
        public static string LessonUpdated = "Lesson Updated Successfuly";
        public static string LessonDeleted = "Lesson Deleted Successfuly";
        public static string LessonNotFound = "Lesson Not Found";
        public static string LessonAlreadyExists = "Lesson Already Exists";
        #endregion

        #region SectionCrudOperationsMessages
        public static string SectionCreated = "Section Created Successfuly";
        public static string SectionUpdated = "Section Updated Successfuly";
        public static string SectionDeleted = "Section Deleted Successfuly";
        public static string SectionNotFound = "Section Not Found";
        public static string SectionAlreadyExists = "Section Already Exists";
        #endregion

        #region CommonMessages
        public static string OperationSuccessful = "Operation Successful";
        public static string OperationFailed = "Operation Failed";
        public static string InvalidInput = "Invalid Input";
        #endregion
    }
}
