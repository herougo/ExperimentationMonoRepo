import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { FetchData } from "./components/FetchData";
import Home from "./components/Home";
import Settings from "./components/Settings";
import Create from "./components/Create";
import QuestionsPage from "./components/QuestionsPage";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/questions',
    requireAuth: true,
    element: <QuestionsPage />
  },
  {
    path: '/create',
    requireAuth: true,
    element: <Create />
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
