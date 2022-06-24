// base styles
import colors from "../base/colors";
import typography from "../base/typography";

const { grey } = colors;
const { size } = typography;

const props = {
  styleOverrides: {
    li: {
      lineHeight: 0,
    },

    separator: {
      fontSize: size.sm,
      color: grey[600],
    },
  },
};
export default props;