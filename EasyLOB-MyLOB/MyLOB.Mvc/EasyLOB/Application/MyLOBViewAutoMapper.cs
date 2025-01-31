using AutoMapper;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Reflection;

namespace MyLOB.Data
{
    public class MyLOBViewAutoMapper : Profile // !!!
    {
        public MyLOBViewAutoMapper()
        {
            Assembly dataAssembly = LibraryHelper.GetAssembly("MyLOB.Data");
            Assembly viewAssembly = Assembly.GetExecutingAssembly();

            Type[] types = dataAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(ZDataModel)))
                {
                    string dto = type.FullName + "DTO";
                    Type typeDTO = dataAssembly.GetType(dto);

                    string viewModel = type.FullName + "ViewModel";
                    Type typeViewModel = viewAssembly.GetType(viewModel);

                    CreateMap(type, typeViewModel, MemberList.None);
                    CreateMap(typeDTO, typeViewModel, MemberList.None);
                    CreateMap(typeViewModel, typeDTO, MemberList.None);
                    CreateMap(typeViewModel, type, MemberList.None);
                }
            }
        }
    }
}
