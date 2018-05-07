﻿//=============== 树型表格查询基类================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, OnInit } from '@angular/core';
import { MessageConfig } from '../config/message-config';
import { util, TreeViewModel, TreeQueryParameter, TreeTable, HttpMethod } from '../index';

/**
 * 树型表格查询基类
 */
export abstract class TreeTableQueryComponentBase<TViewModel extends TreeViewModel, TQuery extends TreeQueryParameter> implements OnInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 选中列表
     */
    selection: TViewModel[];
    /**
     * 传入弹出框的数据
     */
    data;
    /**
     * 表格组件
     */
    @ViewChild(TreeTable) protected table: TreeTable<TViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
        this.selection = new Array<TViewModel>();
    }

    /**
     * 创建查询参数
     * @param data 传入弹出框的数据
     */
    protected abstract createQuery(data?): TQuery;

    /**
     * 初始化
     */
    ngOnInit() {
        this.initDialogData();
    }

    /**
     * 加载弹出框数据
     */
    private initDialogData() {
        this.data = util.dialog.getData();
        if (!this.data)
            return;
        this.addToSelections(this.getSelectionFromData(this.data));
        this.queryParam = this.createQuery(this.data);
        this.init(this.data);
    }

    /**
     * 从弹出框数据中获取选中项
     * @param data 传入弹出框的数据
     */
    protected getSelectionFromData(data) {
        return data;
    }

    /**
     * 添加到选中项列表
     */
    private addToSelections(selection) {
        this.util.helper.addToArray(this.selection, selection);
    }

    /**
     * 初始化
     * @param data 传入弹出框的数据
     */
    protected init(data) {
    }

    /**
     * 查询
     */
    query() {
        this.table.query();
    }

    /**
     * 延迟搜索
     */
    search() {
        this.table.search(this.getDelay());
    }

    /**
     * 获取查询延迟间隔，单位：毫秒，默认500
     */
    protected getDelay() {
        return 500;
    }

    /**
     * 删除
     * @param id 标识
     * @param button 按钮
     */
    delete(id?, button?) {
        id = this.table.getId(id);
        this.table.delete(id, null, null, button);
    }

    /**
     * 刷新
     * @param button 按钮
     */
    refresh(button?) {
        this.queryParam = this.createQuery(this.data);
        this.table.refresh(this.queryParam, button);
    }

    /**
     * 选中实体
     */
    select() {
        let selection = this.selection;
        if (!selection || selection.length === 0) {
            this.util.dialog.close(new TreeViewModel());
            return;
        }
        if (selection.length === 1) {
            this.util.dialog.close(selection[0]);
            return;
        }
        this.util.dialog.close(selection);
    }

    /**
     * 选中行
     * @param node 节点
     * @param event 事件
     */
    selectRow(node, event?) {
        this.table.selectRow(node);
        event && event.stopPropagation();
    }

    /**
     * 是否首行
     * @param node 节点
     */
    isFirst(node) {
        return this.table.isFirst(node);
    }

    /**
     * 是否尾行
     * @param node 节点
     */
    isLast(node) {
        return this.table.isLast(node);
    }

    /**
     * 上移
     * @param node 节点
     * @param button 按钮
     * @param event 事件
     */
    moveUp(node, button?, event?) {
        this.table.moveUp(node, button);
        this.selectRow(node, event);
    }

    /**
     * 下移
     * @param node 节点
     * @param button 按钮
     * @param event 事件
     */
    moveDown(node, button?, event?) {
        this.table.moveDown(node, button);
        this.selectRow(node, event);
    }

    /**
     * 启用
     * @param node 节点
     * @param button 按钮
     * @param url 启用服务端Url
     */
    enable(node?, button?, url?: string) {
        this.enableNode(true, node, button, url);
    }

    /**
     * 禁用
     * @param node 节点
     * @param button 按钮
     * @param url 禁用服务端Url
     */
    disable(node?, button?, url?: string) {
        this.enableNode(false, node, button, url);
    }

    /**
     * 启用禁用
     */
    private enableNode(enabled: boolean, node?, btn?, url?: string) {
        let list = this.getSelectedNodes(node);
        if (!list || list.length === 0) {
            util.message.warn(MessageConfig.notSelected);
            return;
        }
        url = url || `/api/${this.table.baseUrl}/${enabled ? 'enable' : 'disable'}`;
        this.util.form.submit({
            url: url,
            data: this.table.getCheckedIds(list),
            httpMethod: HttpMethod.Post,
            button: btn,
            confirm: this.getEnableConfirmMessage(enabled),
            handler: (result: any[]) => {
                if (!result || result.length === 0)
                    return;
                result.forEach(value => {
                    if (!value)
                        return;
                    let item = list.find(t => t.data.id === value.id);
                    if (!item)
                        return;
                    item.data.enabled = value.enabled;
                    item.data.version = value.version;
                });
            }
        });
    }

    /**
     * 获取选中列表
     */
    private getSelectedNodes(node): any[] {
        let list = new Array();
        if (node && node.data) {
            list.push(node);
            return list;
        }
        return this.table.getChecked();
    }

    /**
     * 获取启用确认消息
     */
    private getEnableConfirmMessage(enabled: boolean) {
        return enabled ? MessageConfig.enableConfirm : MessageConfig.disableConfirm;
    }
}