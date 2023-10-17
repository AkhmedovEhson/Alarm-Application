
import { AppElement } from './App';
import NotificationStoreElement from './Components/Layout/NotificationStore';

const AppRoutes = [
  {
    index: true,
    element: <AppElement/>
  },
  {
    path: '/counter',
    element: <NotificationStoreElement />
  },
];

export default AppRoutes;