import * as axios from "axios";

export function todoRecord_create(data) {
    return axios.get("api/airtable", data);
}