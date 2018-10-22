using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Utils
{
  public static  class PropertyInfoHelper
    {   
        //封装一个获取属性的lambda表达式
        public static PropertyInfo GetPropertyInfoFromLambda<TEntity,TProperty>(Expression<Func<TEntity,TProperty>> model) where TEntity : class
        {
            var memberEx = (MemberExpression)model.Body;
            if(memberEx == null)
            {
                throw new ArgumentNullException(nameof(model), "必须通过Lambda提供属性");
            }
            var propInfo = typeof(TEntity).GetProperty(memberEx.Member.Name);
            if(propInfo==null)
            {
                throw new ArgumentNullException(nameof(model), "所给参数不是属性");
            }
            return propInfo;
        }
    }
}
