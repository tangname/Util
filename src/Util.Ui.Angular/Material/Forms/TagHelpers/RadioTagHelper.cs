﻿using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.Configs;
using Util.Ui.Material.Forms.Renders;
using Util.Ui.Renders;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Forms.TagHelpers {
    /// <summary>
    /// 单选框
    /// </summary>
    [HtmlTargetElement( "util-radio" )]
    public class RadioTagHelper : AngularTagHelperBase {
        /// <summary>
        /// 控件的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 控件的绑定名称 [name]
        /// </summary>
        public string BindName { get; set; }
        /// <summary>
        /// 是否垂直布局
        /// </summary>
        public bool Vertical { get; set; }
        /// <summary>
        /// 是否显示标签
        /// </summary>
        public bool ShowLabel { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 绑定标签
        /// </summary>
        public string BindLabel { get; set; }
        /// <summary>
        /// 标签位置
        /// </summary>
        public XPosition Position { get; set; }
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 数据源
        /// </summary>
        public string DatasSource { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 属性表达式
        /// </summary>
        public ModelExpression For { get; set; }
        /// <summary>
        /// 模型绑定
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 必填项
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// 变更事件处理函数,范例：handle()
        /// </summary>
        public string OnChange { get; set; }
        /// <summary>
        /// 组件不添加到FormGroup，独立存在，这样也无法基于NgForm进行表单验证
        /// </summary>
        public bool Standalone { get; set; }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        /// <param name="context">上下文</param>
        protected override IRender GetRender( Context context ) {
            return new RadioRender( new SelectConfig( context ) );
        }
    }
}