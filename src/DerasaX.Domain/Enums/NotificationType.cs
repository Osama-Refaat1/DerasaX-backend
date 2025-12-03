using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Enums
{
    public enum NotificationType
    {
        General,              
        QuizPublished,            
        QuizGraded,               
        QuizDueSoon,              
        SupportRequestReceived,   
        SupportRequestReplied,    
        OfficeHoursApproved,      
        NewLesson,              
        NewAnnouncement,        
        SystemMaintenance,       
        LateSubmission
    }
}
