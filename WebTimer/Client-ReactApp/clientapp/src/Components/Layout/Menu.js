import {React,Component} from 'react';
import '../../App.css';
import { connect, useSelector } from 'react-redux';
import { WebApi } from '../../web-api';
import { Input } from 'reactstrap';
import { Button } from '@mui/material';
import { getAlarm } from '../../Store/Alarms/AlarmSlice';
import { GetAlarms } from '../../Utills/Thunk/Queries/GetAlarmsQuery';


class Menu extends Component {

    async componentDidMount() {
        await GetAlarms(this.props.dispatch);
    } 

    DateConfigure(obj) {
      if (obj == null)
        return;

      const value = new Date(obj);
      const response = `${value.getDate()} : ${value.getHours()} : ${value.getMinutes()} : ${value.getSeconds()}`;
      return <div>{response}</div>

    }

    ChangeTime() {
      
    }

    componentDidUpdate(prevProps,prevState) {
     console.log(this.props.alarms);
    }
    render() {
        return(
        <nav className='nav-menu'>
                <Input type={'search'} className='search-bar-app' placeholder='search' />
                <div className = 'nav-block-app'>
                { this.props.loading ? <span>loading</span> : this.props.alarms.map(o => {
                        return <div onClick={() => this.props.dispatch(getAlarm(o))} className='found-element-search-bar-app'>{o['day']} : {o['hour']} : {o['minute']} : {o['second']}</div>})
                }
            </div>
              <div className = 'nav-block-app'></div>
        </nav>
        )
    }
}
const mapStateToProps = state => ({
  alarms: state.alarm.alarms,
  alarm:state.alarm.alarm,
  loading:state.alarm.loading
});




export default connect(mapStateToProps)(Menu)