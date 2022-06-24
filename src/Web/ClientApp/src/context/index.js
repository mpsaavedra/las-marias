import { createContext, useContext, useReducer } from "react";
import PropTypes from "prop-types";

// main context
const ApplicationUI = createContext();
ApplicationUI.displayName = "ApplicationUIContext";

// react reducer actions
function reducer(state, action) {
  switch (action.type) {
    case "LAYOUT": {
      return { ...state, layout: action.value };
    }
    default: {
      throw new Error(`Unhandled action type: ${action.type}`);
    }
  }
}

// context provider
function ApplicationUIControllerProvider({ children }) {
  const initialState = {
    miniSidenav: false,
    transparentSidenav: false,
    whiteSidenav: false,
    sidenavColor: "info",
    transparentNavbar: true,
    fixedNavbar: true,
    openConfigurator: false,
    direction: "ltr",
    layout: "dashboard",
    darkMode: false,
  };

  const [controller, dispatch] = useReducer(reducer, initialState);
  return <ApplicationUI.Provider value={[controller, dispatch]}>{children}</ApplicationUI.Provider>;
}

function useApplicationUIController() {
  const context = useContext(ApplicationUI);

  if (!context) {
    throw new Error(
      "useApplicationUIController should be used inside the ApplicationUIControllerProvider"
    );
  }

  return context;
}

// typechecking
ApplicationUIControllerProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

// context module functions
const setLayout = (dispatch, value) => dispatch({ type: "LAYOUT", value });

export { ApplicationUIControllerProvider, useApplicationUIController, setLayout };
