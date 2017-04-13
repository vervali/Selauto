/**
* Media.js
*
* @description :: TODO: You might write a short summary of how this model works and what it represents here.
* @docs        :: http://sailsjs.org/#!documentation/models
*/

module.exports = {

  attributes: {
      test: {
          model: 'test'
      },
      
      log: {
          model: 'log'
      },
      
      project: {
          model: 'project'
      },
      
      report: {
          model: 'report'
      },
      
      testName: 'text',
      
      sequence: 'number',
      path: 'string',
      mediaType: {
          type: 'string',
          enum: ['img', 'vid']
      }
  },

};

