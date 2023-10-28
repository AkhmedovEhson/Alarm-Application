import { Component, useRef } from "react";
import { alarmSlice, getAlarm, unShiftAlarm } from "../../Store/Alarms/AlarmSlice";
import { connect } from "react-redux";
import { WebApi } from "../../web-api";
import { TimerState } from "../../Types/States/TimerState";
import { PostAlarms } from "../../Utills/Thunk/Commands/CreateAlarmCommand";
import { GetAlarms } from "../../Utills/Thunk/Queries/GetAlarmsQuery";
import { Button, Input } from "@mui/material";
import moment from "moment/moment";
import React from "react";


class Timer extends Component {
    #array = []
    #date = new Date();

    constructor(props)
    {
        super(props)
        this.#date.setHours(this.#date.getHours() + 2);
    
        this.state = TimerState;

        this.TimerAppElement = React.createRef();

        // fix: bugfix { ...... }
        console.log("Timer constructor : ", this.props);
        
        this.interval = null;

        for(let i = 0; i <= 59; i++) this.#array[i] = <div>{i}</div> 
    }

    getTime = () => {

        // date config ...


        // time settings ... 
        const time = this.#date - Date.now();
        console.log(this.state.second);
        this.setState({
            day:Math.floor((time / ((1000 * 60 * 60) * 24))), // day
            hour:Math.floor((time / (1000 * 60 * 60)) % 24), // hour
            minute:Math.floor((time / 1000 / 60) % 60), // minute
            second:Math.floor((time / 1000) % 60) // second
            
        });
    };


  async componentDidMount() {
        this.interval = setInterval(() => {
        this.getTime();
    }, 1000);
    const height = this.TimerAppElement.current.getBoundingClientRect().height.toFixed(1);
    this.setState({height:0.0 - height});
    console.log(height);
    }


    componentDidUpdate() {
        // { .... } fill it 
    }

    componentWillUnmount(){
        clearInterval(this.interval);
    }

    // Async operation ( Creates Alarm asynchronously )
    async PostAsync() {
        const date = new Date(this.state.date);
        const request = { ringAt:date.toISOString() }
        await PostAlarms(this.props.dispatch,request);
        await GetAlarms(this.props.dispatch);
    }

    render() {
        
        return(
            <div className='main-app-container'>           
                <div className ='timer-app'>
                    <div id='timer-count-app'>
                        <div id = 'timer-app'>
                        <div id = 'timer-count-time-app'><span style={{color:'steelblue'}}>{this.state.day}</span> : </div>
                        <div id='timer-count-time-app'> {this.state.hour} : </div>
                        <div id='timer-count-time-app'> {this.state.minute} : </div>
                        <div id='timer-count-time-app3' ref={this.TimerAppElement}>
                            <div id = 'seconds-app' style={{transform:`translate(0px,${this.state.height * this.state.second}px)`}}>
                            {this.#array}</div> 
                        </div>
                    </div>
                    <div style={{display:'grid'}}>
            
                        <div className='create-button-time-app'>
                            <Input value={this.state.date} onChange={(e) => this.setState({date:e.target.value})} type="date" />
                         
                        </div>
                            <div id='create-button-block-app'>
                                <Button style={{color:"white"}} id='timer-count-button-time-app' onClick={() => this.PostAsync()}>Create</Button>
                        </div>
                    </div>

                </div>
            </div>
            </div>
        )
    }
}
const mapStateToProps = state => ({
    alarms: state.alarm.alarms,
    alarm:state.alarm.alarm
  });

  
export default connect(mapStateToProps)(Timer)