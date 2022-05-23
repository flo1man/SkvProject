using System;

namespace SkvProject.Services
{
    public interface IDateService
    {
        string GetCreationFromNow<T>(string postId, T model);
    }
}
