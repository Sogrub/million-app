import style from "./loader.module.css";

export const Loader: React.FC = () => {
  return (
    <div className="fixed top-0 left-0 flex justify-center items-center w-screen h-screen bg-black opacity-50">
      <span className={style.loader}></span>
    </div>
  );
};