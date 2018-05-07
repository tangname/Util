﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.Applications.Dtos;
using Util.Applications.Trees;
using Util.Ui.Attributes;

namespace Util.Samples.Webs.Services.Dtos.Systems {
    /// <summary>
    /// 角色数据传输对象
    /// </summary>
    [Model( "model" )]
    public class RoleDto : DtoBase, ITreeNode {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Required( ErrorMessage = "角色编码不能为空" )]
        [StringLength( 256, ErrorMessage = "角色编码输入过长，不能超过256位" )]
        [Display( Name = "角色编码" )]
        [DataMember]
        public string Code { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required( ErrorMessage = "角色名称不能为空" )]
        [StringLength( 256, ErrorMessage = "角色名称输入过长，不能超过256位" )]
        [Display( Name = "角色名称" )]
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 标准化角色名称
        /// </summary>
        [Required( ErrorMessage = "标准化角色名称不能为空" )]
        [StringLength( 256, ErrorMessage = "标准化角色名称输入过长，不能超过256位" )]
        [Display( Name = "标准化角色名称" )]
        [DataMember]
        public string NormalizedName { get; set; }
        /// <summary>
        /// 角色类型
        /// </summary>
        [Required( ErrorMessage = "角色类型不能为空" )]
        [StringLength( 80, ErrorMessage = "角色类型输入过长，不能超过80位" )]
        [Display( Name = "角色类型" )]
        [DataMember]
        public string Type { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        [Display( Name = "管理员" )]
        [DataMember]
        public bool? IsAdmin { get; set; }
        /// <summary>
        /// 父编号
        /// </summary>
        [Display( Name = "父编号" )]
        [DataMember]
        public string ParentId { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        [Required( ErrorMessage = "路径不能为空" )]
        [StringLength( 800, ErrorMessage = "路径输入过长，不能超过800位" )]
        [Display( Name = "路径" )]
        [DataMember]
        public string Path { get; set; }
        /// <summary>
        /// 级数
        /// </summary>
        [Required( ErrorMessage = "级数不能为空" )]
        [Display( Name = "级数" )]
        [DataMember]
        public int? Level { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        [Display( Name = "排序号" )]
        [DataMember]
        public int? SortId { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        [Display( Name = "启用" )]
        [DataMember]
        public bool? Enabled { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 500, ErrorMessage = "备注输入过长，不能超过500位" )]
        [Display( Name = "备注" )]
        [DataMember]
        public string Comment { get; set; }
        /// <summary>
        /// 拼音简码
        /// </summary>
        [StringLength( 200, ErrorMessage = "拼音简码输入过长，不能超过200位" )]
        [Display( Name = "拼音简码" )]
        [DataMember]
        public string PinYin { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        [StringLength( 256, ErrorMessage = "签名输入过长，不能超过256位" )]
        [Display( Name = "签名" )]
        [DataMember]
        public string Sign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display( Name = "创建时间" )]
        [DataMember]
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人编号
        /// </summary>
        [Display( Name = "创建人编号" )]
        [DataMember]
        public Guid? CreatorId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Display( Name = "最后修改时间" )]
        [DataMember]
        public DateTime? LastModificationTime { get; set; }
        /// <summary>
        /// 最后修改人编号
        /// </summary>
        [Display( Name = "最后修改人编号" )]
        [DataMember]
        public Guid? LastModifierId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Display( Name = "是否删除" )]
        [DataMember]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        [DataMember]
        public Byte[] Version { get; set; }
    }
}