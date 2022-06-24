// Base Styles
import colors from "../base/colors";

const { transparent } = colors;

const props = {
  styleOverrides: {
    root: {
      "&:hover": {
        backgroundColor: transparent.main,
      },
    },
  },
};
export default props;