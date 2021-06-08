/*
 * ArticleTag
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 *
 * Swagger Codegen version: 3.0.26
 *
 * Do not edit the class manually.
 *
 */
import {ApiClient} from '../ApiClient';

/**
 * The UserLoginVm model module.
 * @module model/UserLoginVm
 * @version v1
 */
export class UserLoginVm {
  /**
   * Constructs a new <code>UserLoginVm</code>.
   * @alias module:model/UserLoginVm
   * @class
   * @param loginName {String} 
   * @param password {String} 
   */
  constructor(loginName, password) {
    this.loginName = loginName;
    this.password = password;
  }

  /**
   * Constructs a <code>UserLoginVm</code> from a plain JavaScript object, optionally creating a new instance.
   * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
   * @param {Object} data The plain JavaScript object bearing properties of interest.
   * @param {module:model/UserLoginVm} obj Optional instance to populate.
   * @return {module:model/UserLoginVm} The populated <code>UserLoginVm</code> instance.
   */
  static constructFromObject(data, obj) {
    if (data) {
      obj = obj || new UserLoginVm();
      if (data.hasOwnProperty('loginName'))
        obj.loginName = ApiClient.convertToType(data['loginName'], 'String');
      if (data.hasOwnProperty('password'))
        obj.password = ApiClient.convertToType(data['password'], 'String');
    }
    return obj;
  }
}

/**
 * @member {String} loginName
 */
UserLoginVm.prototype.loginName = undefined;

/**
 * @member {String} password
 */
UserLoginVm.prototype.password = undefined;

