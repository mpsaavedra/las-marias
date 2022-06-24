// base styles
import typography from "../../base/typography";
import colors from "../../base/colors";

// helper functions
// import pxToRem from "../../functions/pxToRem";

const { size } = typography;
const { text } = colors;

const props = {
  styleOverrides: {
    root: {
      fontSize: size.md,
      color: text.main,
    },
  },
};
export default props;