import RestApi from './rest-api'

interface Data {
  user: {
    address: string
  }
}
class HomesApi extends RestApi {
  constructor(requestUrl?: string) {
    super(requestUrl || '')
  }

  saveHome = (data: Data) => {
    debugger
    return this.postRestRequest({
      url: 'api/Entities/Add/Houses',
      data: data.user,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default HomesApi
