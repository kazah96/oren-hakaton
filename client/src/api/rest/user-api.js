import RestApi from './rest-api';

class UserApi extends RestApi {

  getAllUser = () => {
    return this.getRestRequest({
      url: 'api/auth',
    }).then(result => {
      return Promise.resolve(result.content);
    });
  };

  saveUser = data => {
    return this.postRestRequest({
      url: 'api/auth',
      data: data.user
    }).then(result => {
      return Promise.resolve(result.content);
    });
  }
}

export default UserApi;