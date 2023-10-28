import { WebApi } from "../../../web-api";

export const PostAlarms = async (dispatch,payload) => {
    const WebAPIs = new WebApi();
    await dispatch(WebAPIs.PostAlarm(payload))
}