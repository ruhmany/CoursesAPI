namespace RahmanyCourses.Core.Static_Data
{
    public static class EmailTemplates
    {
        public static string CourseUploaded(string instructorName, string courseTitle)
        {
            return $@"
            Hello,

            {instructorName} has just published a new course: **{courseTitle}**.

            Visit the platform to check it out!

            Thanks,
            Courses Platform Team";
        }

        public static string CourseUpdated(string courseTitle)
        {
            return $@"
                Hello,

                The course **{courseTitle}** you subscribed to has been updated.

                Log in to see the latest content!

                Best,
                Courses Platform Team";
        }

        public static string NewSubscriber(string courseTitle, string studentName)
        {
            return $@"
                Hello,

                {studentName} has just subscribed to your course: **{courseTitle}**.

                Keep up the great work!

                Cheers,
                Courses Platform Team";
        }

        public static string NewComment(string courseTitle, string commenterName, string comment)
        {
            return $@"
                Hello Instructor,

                {commenterName} has left a comment on your course **{courseTitle}**:

                ""{comment}""

                Reply or engage from your dashboard.

                Thank you,
                Courses Platform Team";
        }
    }
}
