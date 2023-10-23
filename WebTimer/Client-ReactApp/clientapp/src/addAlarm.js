import {createSlice} from '@reduxjs/toolkit';
import { WebApi } from './web-api';


export const alarmSlice = createSlice({
    name:'alarms',
    initialState:{
        alarms:[],
        loading:true
    },
    reducers:{
        addAlarm(state,action) {
            state.alarms.push(...action.payload)
        },      
    },
    extraReducers:builder => {
        const web = new WebApi();
        builder.addCase(web.GetAlarms.pending,(state) => {
            state.loading = true;
        });
        builder.addCase(web.GetAlarms.fulfilled,(state,action) => {
            state.alarms = action.payload;
            state.loading = false;
        });

    }
})

export const {addAlarm} = alarmSlice.actions;
export const alarmReducer = alarmSlice.reducer;

