/**
 * ArticleTag
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 *
 */

import ApiClient from "../ApiClient";
import ArticleDtoResponse from '../model/ArticleDtoResponse';
import ArticleRecordRequest from '../model/ArticleRecordRequest';
import AuditArticleRequest from '../model/AuditArticleRequest';
import BooleanResponse from '../model/BooleanResponse';
import TagArticleStatusEnum from '../model/TagArticleStatusEnum';
import TaggedRecordDtoResponse from '../model/TaggedRecordDtoResponse';

/**
* Article service.
* @module api/ArticleApi
* @version v1
*/
export default class ArticleApi {

    /**
    * Constructs a new ArticleApi. 
    * @alias module:api/ArticleApi
    * @class
    * @param {module:ApiClient} [apiClient] Optional API client implementation to use,
    * default to {@link module:ApiClient#instance} if unspecified.
    */
    constructor(apiClient) {
        this.apiClient = apiClient || ApiClient.instance;
    }

    /**
     * Callback function to receive the result of the apiArticleAuditArticlePost operation.
     * @callback module:api/ArticleApi~apiArticleAuditArticlePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleAuditArticlePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleAuditArticlePost(opts, callback) {
      opts = opts || {};
      let postBody = opts['body'];

      let pathParams = {
      };
      let queryParams = {
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = ['application/json', 'text/json', 'application/_*+json'];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/AuditArticle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleCheckCanAuditPost operation.
     * @callback module:api/ArticleApi~apiArticleCheckCanAuditPostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleCheckCanAuditPostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleCheckCanAuditPost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'articleId': opts['articleId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/CheckCanAudit', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleCheckCanEditPost operation.
     * @callback module:api/ArticleApi~apiArticleCheckCanEditPostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleCheckCanEditPostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleCheckCanEditPost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'articleId': opts['articleId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/CheckCanEdit', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleDistributeArticlePost operation.
     * @callback module:api/ArticleApi~apiArticleDistributeArticlePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/ArticleDtoResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleDistributeArticlePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/ArticleDtoResponse}
     */
    apiArticleDistributeArticlePost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'taggerId': opts['taggerId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = ArticleDtoResponse;

      return this.apiClient.callApi(
        '/api/Article/DistributeArticle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleGetTaggersCanAuditArticlePost operation.
     * @callback module:api/ArticleApi~apiArticleGetTaggersCanAuditArticlePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/ArticleDtoResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleGetTaggersCanAuditArticlePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/ArticleDtoResponse}
     */
    apiArticleGetTaggersCanAuditArticlePost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'taggerId': opts['taggerId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = ArticleDtoResponse;

      return this.apiClient.callApi(
        '/api/Article/GetTaggersCanAuditArticle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticlePagingAritclePost operation.
     * @callback module:api/ArticleApi~apiArticlePagingAritclePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/TaggedRecordDtoResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticlePagingAritclePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/TaggedRecordDtoResponse}
     */
    apiArticlePagingAritclePost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'page': opts['page'],
        'size': opts['size'],
        'status': opts['status'],
        'review': opts['review']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = TaggedRecordDtoResponse;

      return this.apiClient.callApi(
        '/api/Article/PagingAritcle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleSaveTaggedRecordPost operation.
     * @callback module:api/ArticleApi~apiArticleSaveTaggedRecordPostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleSaveTaggedRecordPostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleSaveTaggedRecordPost(opts, callback) {
      opts = opts || {};
      let postBody = opts['body'];

      let pathParams = {
      };
      let queryParams = {
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = ['application/json', 'text/json', 'application/_*+json'];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/SaveTaggedRecord', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleSearchArticleByTaggerPost operation.
     * @callback module:api/ArticleApi~apiArticleSearchArticleByTaggerPostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/TaggedRecordDtoResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleSearchArticleByTaggerPostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/TaggedRecordDtoResponse}
     */
    apiArticleSearchArticleByTaggerPost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'tagger': opts['tagger'],
        'page': opts['page'],
        'size': opts['size'],
        'status': opts['status'],
        'review': opts['review']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = TaggedRecordDtoResponse;

      return this.apiClient.callApi(
        '/api/Article/SearchArticleByTagger', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleSearchArticlePost operation.
     * @callback module:api/ArticleApi~apiArticleSearchArticlePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/ArticleDtoResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleSearchArticlePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/ArticleDtoResponse}
     */
    apiArticleSearchArticlePost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'articleId': opts['articleId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = ArticleDtoResponse;

      return this.apiClient.callApi(
        '/api/Article/SearchArticle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleSetReviewArticlePost operation.
     * @callback module:api/ArticleApi~apiArticleSetReviewArticlePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleSetReviewArticlePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleSetReviewArticlePost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'articleId': opts['articleId'],
        'review': opts['review']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/SetReviewArticle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleSetUnavailArticlePost operation.
     * @callback module:api/ArticleApi~apiArticleSetUnavailArticlePostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleSetUnavailArticlePostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleSetUnavailArticlePost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'articleId': opts['articleId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/SetUnavailArticle', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }
    /**
     * Callback function to receive the result of the apiArticleSubmitAuditPost operation.
     * @callback module:api/ArticleApi~apiArticleSubmitAuditPostCallback
     * @param {String} error Error message, if any.
     * @param {module:model/BooleanResponse} data The data returned by the service call.
     * @param {String} response The complete HTTP response.
     */

    /**
     * @param {Object} opts Optional parameters
     * @param {module:api/ArticleApi~apiArticleSubmitAuditPostCallback} callback The callback function, accepting three arguments: error, data, response
     * data is of type: {@link module:model/BooleanResponse}
     */
    apiArticleSubmitAuditPost(opts, callback) {
      opts = opts || {};
      let postBody = null;

      let pathParams = {
      };
      let queryParams = {
        'articleId': opts['articleId']
      };
      let headerParams = {
      };
      let formParams = {
      };

      let authNames = ['Bearer'];
      let contentTypes = [];
      let accepts = ['text/plain', 'application/json', 'text/json'];
      let returnType = BooleanResponse;

      return this.apiClient.callApi(
        '/api/Article/SubmitAudit', 'POST',
        pathParams, queryParams, headerParams, formParams, postBody,
        authNames, contentTypes, accepts, returnType, callback
      );
    }

}
