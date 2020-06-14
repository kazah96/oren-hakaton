import RestApi from './rest-api'

interface Data {
  user: {
    address: string
  }
}
class MeetingsApi extends RestApi {
  constructor(requestUrl?: string) {
    super(requestUrl || '')
  }

  getAllMeetings = () => {
    return this.getRestRequest({
      url: 'api/Entities/GetAll/Meetings',
    }).then((result) => {
      return Promise.resolve(result)
    })
  }

  saveMeeting = (data: Data) => {
    return this.postRestRequest({
      url: 'api/Entities/Add/Meetings',
      data,
    }).then((result) => {
      return Promise.resolve(result)
    })
  }
}

export default MeetingsApi
