namespace TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TP_CS_ZORK.DATA_ACCESS_LAYER.Models;
    using TP_CS_ZORK.DATA_ACCESS_LAYER.Utils;

    public abstract class BaseAccessLayer<TModel>
    where TModel : BaseDataObject
    {
        /// <summary>
        ///     Gets the Db context.
        /// </summary>
        private readonly ZorkDbContext context;

        /// <summary>
        ///     Gets the Db model set.
        /// </summary>
        protected readonly DbSet<TModel> modelSet;

        protected List<string> CollectionNavigationProperties = new List<string>();
        protected List<string> ReferenceNavigationProperties = new List<string>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseAccessLayer{TModel}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        protected BaseAccessLayer(ZorkDbContext context)
        {
            this.context = context;
            this.modelSet = this.context.Set<TModel>();
        }

        /// <summary>
        ///     Async Method that add new object in Db.
        /// </summary>
        /// <param name="model">Object model to add</param>
        /// <returns>Returns the Id of newly created object.</returns>
        public async Task<int> AddAsync(TModel model)
        {
            var result = this.modelSet.Add(model);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result.Entity.Id;
        }

        /// <summary>
        ///     Async Method that add new objects in Db.
        /// </summary>
        /// <param name="models">Object models to add</param>
        /// <returns>Returns the Ids of newly created objects.</returns>
        public async Task<int[]> AddManyAsync(TModel[] models)
        {
            var ids = new List<int>();
            foreach(TModel model in models)
            {
                var result = this.modelSet.Add(model);
                ids.Add(result.Entity.Id);
            }
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return ids.ToArray();
        }

        /// <summary>
        ///     Method that retrieve a collection of data according to the filter.
        /// </summary>
        /// <remarks>
        ///     Tracking on data returned is disabled by default. 
        /// </remarks>
        /// <param name="filter">Expression to filter data to return.</param>
        /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
        /// <returns>Returns Enumerable of <typeparamref name="TModel" />.</returns>
        public IEnumerable<TModel> GetCollection(Expression<Func<TModel, bool>> filter = null, bool trackingEnabled = false)
        {
            var dbQuery = this.modelSet.AsQueryable();

            var filterToApply =
                filter == null
                ? x => true
                : filter;

            var collection = trackingEnabled
                            ? dbQuery.Where(filterToApply)
                            : dbQuery.AsNoTracking().Where(filterToApply);

            return collection;
        }

        /// <summary>
        ///     Async Method that retrieve first data object matching the given filter.
        /// </summary>
        /// <remarks>
        ///     Tracking on data returned is disabled by default.
        /// </remarks>
        /// <param name="filter">filter to apply</param>
        /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
        /// <returns>Returns <typeparamref name="TModel" />.</returns>
        public TModel GetSingle(Expression<Func<TModel, bool>> filter, bool trackingEnabled = false)
        {
            var dbQuery = this.modelSet.AsQueryable();

            var item = trackingEnabled
                            ? dbQuery.FirstOrDefault(filter)
                            : dbQuery.AsNoTracking().FirstOrDefault(filter);

            foreach (string fk in this.CollectionNavigationProperties)
            {
                context.Entry(item).Collection(fk).Load();
               

                //    string fkTypeString = $"TP_CS_ZORK.DATA_ACCESS_LAYER.Models.{fk.Remove(fk.Length - 1)}, TP_CS_ZORK.DATA_ACCESS_LAYER";
                //    var fkType = Type.GetType(fkTypeString);

                //    var fkObjectCollection = (ICollection<fkType.GetGenericTypeDefinition()>) Utils.GetPropValue(item, fk);
                //    string objectToInstantiate = $"TP_CS_ZORK.DATA_ACCESS_LAYER.AccessLayers.{fk}AccessLayer, TP_CS_ZORK.DATA_ACCESS_LAYER";
                //    var objectType = Type.GetType(objectToInstantiate);
                //    var foreignAccessLayer = (BaseAccessLayer<TModel>) objectType.GetMethod("GetInstance").Invoke(null, null);

                //    var i = 0;
                //    foreach (fkType fkObject in fkObjectCollection)
                //    {
                //        foreach(string fktemp in foreignAccessLayer.ReferenceNavigationProperties)
                //        {
                //            context.Entry(fkObject).Collection(fktemp).Load();
                //        }
                //    }
                //    i++;

            }

            foreach (string fk in this.ReferenceNavigationProperties)
            {
                context.Entry(item).Reference(fk).Load();

            }

            return item;
        }

        /// <summary>
        ///     Async method that update a specific data object.
        ///     The entity to update should be tracked ! (context.Entity(model).State should be "Modified" and not "Detached"
        /// </summary>
        /// <param name="model">The object data model to update.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> UpdateAsync(TModel model)
        {
            this.modelSet.Update(model);
            return await this.context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Removes an object by its Id
        /// </summary>
        /// <param name="id">if of object to remove</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> RemoveAsync(int id)
        {
            this.modelSet.Remove(this.modelSet.FirstOrDefault(model => model.Id == id));
            return await this.context.SaveChangesAsync().ConfigureAwait(false);
        }


    }
}
