import {React,Component} from 'react';
import '../../App.css';
import { connect, useSelector } from 'react-redux';
import { GetAlarms, WebApi } from '../../web-api';
import AlarmItems from './AlarmItems';

class Menu extends Component {


  constructor(props){
    super(props);
  }
    componentDidMount() {
      GetTimes(this.props.dispatch)
    } 

    DateConfigure(obj) {
      if (obj == null)
        return;

      const value = new Date(obj);
      const response = `${value.getHours()} : ${value.getMinutes()} : ${value.getSeconds()}`;
      return <div>{response}</div>

    }

    componentDidUpdate(prevProps,prevState) {
      console.log(this.props.alarms.length);
    }
    render() {
        return(
        <nav className='nav-menu'>
                <input className='search-bar-app' placeholder='search' />


                <div className = 'nav-block-app'>
                {
                  this.props.loading ? "loading" : this.props.alarms.map(o => {
                        return <div className='found-element-search-bar-app'>{ 
                          this.DateConfigure(o['ringAt']) ?? " ---- "
                          }</div>
                        })
                }
            </div>
                <div className = 'nav-block-app'>
               
                      
            </div>
        </nav>
        )
    }
}
const mapStateToProps = state => ({
  alarms: state.alarm.alarms,
  loading:state.alarm.loading
});

const GetTimes = (dispatch) => {
  const webapi = new WebApi();
  dispatch(webapi.GetAlarms());
}


export default connect(mapStateToProps)(Menu)