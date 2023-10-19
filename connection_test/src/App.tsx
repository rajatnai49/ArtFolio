import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import "./App.css";

function App() {
  const [values, setValues] = useState();

  const { id } = useParams();

  useEffect(() => {
    const apiUrl = `https://localhost:44315/api/values/${id}`;
    axios
      .get(apiUrl)
      .then((response) => {
        setValues(response.data);
        console.log(response.data);
      })
      .catch((error) => {
        console.error("Error fetching data:", error);
      });
  }, [id]);

  if (!values) {
    return <div>Loading...</div>;
  }

  return (
    <div className="w-screen text-white bg-black text-center">
      {/* User Section */}
      <div className="user-section flex flex-row w-full justify-center items-center p-20">
        <div className="m-4 flex flex-col justify-center items-center">
          <p className="text-5xl my-3 font-black">
            Hello there, 👋🏽 I am {values.Name}
          </p>
          <p className="text-xl my-3 font-semibold w-5/6 text-center">
            {values.Description}
          </p>
        </div>
        <div className="m-4">
          <img
            src={`data:image/jpeg;base64,${values.DisplayPicture}`}
            alt={`Display Picture for ${values.Name}`}
            className="w-1/2 rounded-md shadow-lg shadow-orange-800"
            onError={(e) => console.error("Error loading DisplayPicture", e)}
          />
        </div>
      </div>

      {/* Work Section */}
      <div className="work-section p-20 flex flex-col w-full justify-center items-center">
        <p className="text-5xl my-3 font-black underline">My Work</p>

        <div className="m-4 w-full flex justify-center items-center">
          <img
            src={`data:image/jpeg;base64,${values.WorkImage}`}
            alt={`Work Image for ${values.Name}`}
            className="w-[70%] rounded-md shadow-lg shadow-orange-800"
            onError={(e) => console.error("Error loading WorkImage", e)}
          />
        </div>
        <p className="text-2xl my-8 font-semibold px-16">
          {values.WorkDescription}.
        </p>
        <div className="m-4 w-full grid grid-cols-3 gap-14">
          {values.Photos &&
            values.Photos.map((photo, index) => (
              <div
                key={index}
                className="w-full h-100 bg-cover bg-center rounded-md shadow-lg shadow-orange-800 m-10"
              >
                <img
                  src={`data:image/jpeg;base64,${photo.Image}`}
                  alt={`Image ${index}`}
                  className="w-full h-full rounded-md"
                />
                <p className="text-white text-center mt-8 font-black text-2xl">
                  {photo.Desc}
                </p>
              </div>
            ))}
        </div>
      </div>

      {/* Contact Section */}
      <div className="contact-section flex flex-col w-full justify-center items-center">
        <p className="text-5xl my-3 font-black underline">Contact Me</p>
        <div className="flex flex-col justify-center items-center">
          <div className="m-1 flex flex-col justify-center items-center">
            <p className="text-xl my-3">Mobile: +91 {values.Contact.Mobile}</p>
          </div>
          <div className="mt-1 mb-20 flex flex-row justify-center items-center">
            <a
              className="m-2 text-2xl font-semibold text-white hover:text-orange-300 hover:underline"
              href={values.Contact.Email}
              target="_blank"
            >
              Email
            </a>
            <a
              className="m-2 text-2xl font-semibold text-white hover:text-orange-300 hover:underline"
              href={values.Contact.Twitter}
              target="_blank"
            >
              Twitter
            </a>
            <a
              className="m-2 text-2xl font-semibold text-white hover:text-orange-300 hover:underline"
              href={values.Contact.Facebook}
              target="_blank"
            >
              Facebook
            </a>
            <a
              className="m-2 text-2xl font-semibold text-white hover:text-orange-300 hover:underline"
              href={values.Contact.Instagram}
              target="_blank"
            >
              Instagram
            </a>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
