import {createSlice} from '@reduxjs/toolkit';
import { WebApi } from '../../web-api';
export const alarmSlice = createSlice({
    name:'alarms',
    initialState: {
        alarms:[],
        loading:true,
        alarm:{ringAt:null}
    },
    reducers:{
        addAlarms(state,action) {
            state.alarms.push(...action.payload)
        },      
        unShiftAlarm(state,action){
            state.alarms.unshift(...action.payload)
        },
        getAlarm(state,action) {
            state.alarm.ringAt = action.payload;
        }
    },
    extraReducers:builder => {
        const web = new WebApi();
        web.GetAlarms()
        builder.addCase(web.GetAlarms.pending,(state) => {
            state.loading = true;
        });
        builder.addCase(web.GetAlarms.fulfilled,(state,action) => {
            state.alarms = action.payload;
            state.loading = false;
        });

    }
})

export const {addAlarms,unShiftAlarm,getAlarm} = alarmSlice.actions;
export const alarmReducer = alarmSlice.reducer;

