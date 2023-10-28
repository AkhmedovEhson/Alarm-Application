
import {createSlice,createAsyncThunk} from '@reduxjs/toolkit';
import { Dispatch } from 'react';
import { addAlarm, addAlarms, unShiftAlarm } from './Store/Alarms/AlarmSlice';
import { GetAlarms } from './Components/Layout/Timer';


export class WebApi {
    // constructor () 
    constructor() {}
    
    // Get request ...
    GetAlarms = createAsyncThunk(
        'api/Alarm',
        async function(request){
            const response = await fetch("https://localhost:7022/api/Alarm",{
                method:'GET',
            })
    
            const data = await response.json();
            
            return data;

        
        }
    )

    // Post request ...
    PostAlarm = createAsyncThunk(
        'api/Alarm',
        async function(request,{dispatch}) {
            
            const response = await fetch("https://localhost:7022/api/Alarm",{
                method: "POST",
                headers:{
                    'Accept':'text/plain',
                 'Content-type': 'application/json'
                },
                body:JSON.stringify(request)
            })
    
            const data = await response.json();
    
            dispatch(addAlarms(data));

            console.log("added to initial state");
    
            return data;
        }
    )
}