﻿using Util.Applications;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Exceptions;
using Util.Samples.Webs.Datas;
using Util.Samples.Webs.Domains.Models;
using Util.Samples.Webs.Domains.Repositories;
using Util.Samples.Webs.Services.Abstractions.Systems;
using Util.Samples.Webs.Services.Dtos.Systems;
using Util.Samples.Webs.Services.Queries.Systems;

namespace Util.Samples.Webs.Services.Implements.Systems {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : CrudServiceBase<Application, ApplicationDto, ApplicationQuery>, IApplicationService {
        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="applicationRepository">应用程序仓储</param>
        public ApplicationService( ISampleUnitOfWork unitOfWork, IApplicationRepository applicationRepository )
            : base( unitOfWork, applicationRepository ) {
            ApplicationRepository = applicationRepository;
        }

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        public IApplicationRepository ApplicationRepository { get; set; }

        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">应用程序查询实体</param>
        protected override IQueryBase<Application> CreateQuery( ApplicationQuery param ) {
            return new Query<Application>( param )
                .Or( t => t.Code.Contains( param.Keyword ),t=> t.Name.Contains( param.Keyword ), t => t.Comment.Contains( param.Keyword ) );
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected override void CreateBefore( Application entity ) {
            base.CreateBefore( entity );
            if( ApplicationRepository.Exists( t => t.Code == entity.Code ) )
                ThrowCodeRepeatException( entity.Code );
            if( ApplicationRepository.Exists( t => t.Name == entity.Name ) )
                ThrowNameRepeatException( entity.Name );
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        private void ThrowCodeRepeatException( string code ) {
            throw new Warning( string.Format( "应用程序编码 {0} 已存在，请修改", code ) );
        }

        /// <summary>
        /// 抛出名称重复异常
        /// </summary>
        private void ThrowNameRepeatException( string name ) {
            throw new Warning( string.Format( "应用程序名称 {0} 已存在，请修改", name ) );
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore( Application entity ) {
            base.UpdateBefore( entity );
            if( ApplicationRepository.Exists( t => t.Id != entity.Id && t.Code == entity.Code ) )
                ThrowCodeRepeatException( entity.Code );
            if( ApplicationRepository.Exists( t => t.Id != entity.Id && t.Name == entity.Name ) )
                ThrowNameRepeatException( entity.Name );
        }
    }
}