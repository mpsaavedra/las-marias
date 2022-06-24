// base styles
import borders from "../../base/borders";
import boxShadows from "../../base/boxShadows";

const { borderRadius } = borders;
const { xxl } = boxShadows;

const props = {
  styleOverrides: {
    paper: {
      borderRadius: borderRadius.lg,
      boxShadow: xxl,
    },

    paperFullScreen: {
      borderRadius: 0,
    },
  },
};
export default props;