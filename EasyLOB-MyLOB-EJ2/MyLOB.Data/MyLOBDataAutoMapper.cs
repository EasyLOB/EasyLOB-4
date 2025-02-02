using AutoMapper;
using EasyLOB.Data;
using System;
using System.Reflection;

namespace MyLOB.Data
{
    public class MyLOBDataAutoMapper : Profile
    {
        public MyLOBDataAutoMapper()
        {
            Assembly dataAssembly = Assembly.GetExecutingAssembly();

            Type[] types = dataAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(ZDataModel)))
                {
                    string dto = type.FullName + "DTO";
                    Type typeDTO = dataAssembly.GetType(dto);

                    CreateMap(type, typeDTO, MemberList.None);
                    CreateMap(typeDTO, type, MemberList.None);
                }
            }
        }
    }
}
