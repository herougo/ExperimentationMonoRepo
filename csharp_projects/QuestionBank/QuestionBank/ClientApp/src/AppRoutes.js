import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { FetchData } from "./components/FetchData";
import Home from "./components/Home";
import Settings from "./components/Settings";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/fetch-data',
    requireAuth: true,
    element: <FetchData />
  },
  {
    path: '/settings',
    requireAuth: true,
    element: <Settings />
  },
  ...ApiAuthorzationRoutes
];

export default AppRoutes;
