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

  getAllHouses = () => {
    return this.getRestRequest({
      url: 'api/Entities/GetAll/Houses',
    }).then((result) => {
      return Promise.resolve(result)
    })
  }

  saveHome = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Houses',
      data,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default HomesApi
