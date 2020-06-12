import RestApi from './rest-api';

class UserApi extends RestApi {

  CheckUser = () => {
    return this.getRestRequest({
      url: 'api/auth/CheckAuthoriz',
    }).then(result => {
      return Promise.resolve(result.content);
    });
  };

  saveUser = data => {
    return this.postRestRequest({
      url: 'api/auth/AddUser',
      data: data.user
    }).then(result => {
      return Promise.resolve(result.content);
    });
  }
}

export default UserApi;