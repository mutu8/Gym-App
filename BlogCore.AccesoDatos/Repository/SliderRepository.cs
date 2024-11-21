﻿using BlogCore.AccesoDatos.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Repository
{
    public class SliderRepository : Repository<Slider>, ISliderRepository
    {
        private readonly ApplicationDbContext _db;
        
        public SliderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Slider slider)
        {
            var objDesdeBd = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            objDesdeBd.Nombre = slider.Nombre;
            objDesdeBd.Estado = slider.Estado;
            objDesdeBd.urlImagen = slider.urlImagen;

            //_db.SaveChanges();
        }

    }
}
