﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tibos.Service;
using Tibos.Service.Contract;


namespace Tibos.Confing.autofac
{
    public class DefaultModule : Module
    {
        //Autofac容器
        protected override void Load(ContainerBuilder builder)
        {

            //注入测试服务
            //builder.RegisterType<TestService>().As<ITestService>();

            //拦截器
            //builder.Register(c => new AOPTest());

            //注入清单
            builder.RegisterType<UsersService>().As<UsersIService>().PropertiesAutowired().EnableInterfaceInterceptors();
        }
    }
}