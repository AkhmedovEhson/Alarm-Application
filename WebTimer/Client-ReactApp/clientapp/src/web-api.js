
import {createSlice,createAsyncThunk} from '@reduxjs/toolkit';
import { Dispatch } from 'react';
import { addAlarm } from './addAlarm';


export class WebApi {
    constructor() {}
    
    
    GetAlarms = createAsyncThunk(
        'api/Alarm',
        async function(_,{request}) {
            const response = await fetch("https://localhost:7022/api/Alarm",{
                method:'GET',
            })
    
            const data = await response.json();
            
            return data;
        }
    )
    PostAlarm = createAsyncThunk(
        'api/Alarm',
        async function(request,{dispatch}) {
    
            const response = await fetch("https://localhost:7022/api/Alarm",{
                method: "POST",
                headers:{
                    'Accept':'text/plain',
                 'Content-type': 'application/json'
                },
                body:JSON.stringify({"ringAt": "2023-10-20T04:37:59.424Z"})
            })
    
            const data = await response.json();
        
    
            dispatch(addAlarm(data))
            console.log("added to initial state");
    
            return data;
        }
    )
}